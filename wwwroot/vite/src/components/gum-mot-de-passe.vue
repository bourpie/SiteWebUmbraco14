<template>
  <div class="gum-mot-de-passe">
    <div
      class="gum-form md-form"
      v-bind:class="{
        disabled: disabled,
        erreur: invalid && type === 'nouveau',
        'focus-out': !focus,
      }"
      v-on:mouseover="hover = true"
      v-on:mouseleave="hover = false"
    >
      <div
        class="separateur-animated"
        v-bind:class="{
          active: isActive,
          hovered: hover,
          erreur: invalid && type === 'nouveau',
        }"
      >
        <input
          ref="motdepasse"
          class="form-control mb-1"
          v-model="motdepasse"
          v-bind:type="passwordType"
          v-bind:id="name"
          v-bind:name="name"
          v-bind:value="value"
          v-bind:disabled="disabled"
          v-bind:aria-describedby="'pass-' + name"
          v-bind:aria-invalid="invalid"
          v-bind:aria-required="true"
          v-on:input="
            updateValue($event.target.value);
            password_check($event.target.value);
          "
          v-on:blur="
            updateValue($event.target.value);
            isActive = false;
          "
          v-on:focus="
            isActive = true;
            (hover = true), (focus = true);
          "
          v-on:focusout="
            isActive = false;
            (hover = false), (focus = false);
          "
          v-on:mouseover="hover = true"
          v-on:mouseleave="hover = false"
          v-on:click="showValidation = true"
          autocomplete="new-password"
        />
        <label
          v-bind:class="{
            active: isActive || this.value !== '',
            'text-danger': invalid && type === 'nouveau',
          }"
          v-bind:for="name"
        >
          {{ label }}
          <span
            v-if="required"
            v-bind:class="{
              'text-danger': !passwordsFilled,
              'text-danger': invalid && type === 'nouveau',
              'champ-obligatoire': !focus && !hover,
            }"
          >
            *
          </span>
        </label>
        <span
          role="button"
          class="fas"
          :style="
            hidePassword === true
              ? 'background-image: url(../assets/Img/eye-regular.svg)'
              : 'background-image: url(../assets/Img/eye-slash-regular.svg)'
          "
          @keyup.enter="togglePasswordVisible"
          @click="togglePasswordVisible"
        >
        </span>
      </div>

      <transition name="fade">
        <div
          v-if="showValidation && type === 'nouveau'"
          id="'pass-'+ name"
          class="invalid-feedback mb-32px"
          role="alert"
          aria-live="polite"
        >
          <p class="texte-validation-motdepasse">
            Pour des raisons de sécurité, votre mot de passe doit contenir au minimum :
          </p>
          <ul class="list-unstyled">
            <li class="texte-validation-motdepasse">
              <transition name="fade">
                <img
                  src="../assets/img/valide.svg"
                  v-if="has_ten_caracters"
                  class="check-valid"
                  alt=""
                />
              </transition>
              {{ messageDixCaracteres }}
            </li>
            <li class="texte-validation-motdepasse">
              <transition name="fade">
                <img
                  src="../assets/img/valide.svg"
                  v-if="has_uppercase"
                  class="check-valid"
                  alt=""
                />
              </transition>
              {{ messageMajuscule }}
            </li>
            <li class="texte-validation-motdepasse">
              <transition name="fade">
                <img
                  src="../assets/img/valide.svg"
                  v-if="has_number"
                  class="check-valid"
                  alt=""
                />
              </transition>
              {{ messageChiffre }}
            </li>
            <li class="texte-validation-motdepasse">
              <transition name="fade">
                <img
                  src="../assets/img/valide.svg"
                  v-if="has_special"
                  class="check-valid"
                  alt=""
                />
              </transition>
              {{ messageSymbole }}
            </li>
          </ul>
        </div>
      </transition>
    </div>
  </div>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";

export default {
  mixins: [mixinComposantsFormulaire],

  data: function() {
    return {
      motdepasse: "",
      hidePassword: true,
      showValidation: false,
      has_ten_caracters: false,
      has_uppercase: false,
      has_number: false,
      has_special: false,
    };
  },
  methods: {
    togglePasswordVisible: function() {
      this.hidePassword = !this.hidePassword;
    },
    password_check: function(value) {
      this.has_ten_caracters = /.{10,}/.test(value);
      this.has_uppercase = /[A-Z]+/.test(value);
      this.has_number = /[0-9]+/.test(value);
      this.has_special = /[!@#\$%\^\&*\)\(+=._-]/.test(value);

      this.$emit("inputpassword", this.valid);
    },
  },
  computed: {
    passwordType: function() {
      return this.hidePassword ? "password" : "text";
    },
    passwordsFilled: function() {
      return this.motdepasse !== "";
    },
    valid: function() {
      return (
        this.has_ten_caracters &&
        this.has_uppercase &&
        this.has_number &&
        this.has_special
      );
    },
    invalid: function() {
      if (this.passwordsFilled) {
        return (
          !this.has_ten_caracters ||
          !this.has_uppercase ||
          !this.has_number ||
          !this.has_special
        );
      }
    },
    messageDixCaracteres: function() {
      return this.lang === "fr-CA" ? "10 caractères" : "10 characters";
    },
    messageMajuscule: function() {
      return this.lang === "fr-CA" ? "1 majuscule" : "1 capital letter";
    },
    messageChiffre: function() {
      return this.lang === "fr-CA" ? "1 chiffre" : "1 number";
    },
    messageSymbole: function() {
      return this.lang === "fr-CA"
        ? "1 symbole ou caractère spécial (ex.: !, $, #, %)"
        : "1 symbol ou special character (eg., !, $, #, %)";
    },
  },
};
</script>
