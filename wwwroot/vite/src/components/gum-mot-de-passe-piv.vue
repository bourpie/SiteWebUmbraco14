<template>
  <div class="gum-mot-de-passe gum-mot-de-passe-piv">
    <div class="gum-textbox-piv position-relative" :class="{ error: afficherErreur }">
      <label :for="id" class="d-block"><span v-html="label"></span> <span class="champ-obligatoire text-danger" aria-hidden="true" v-if="!vEmpty && v.$params.required">*</span></label>
      <div class="position-relative">
        <input 
          :type="passwordType" 
          v-bind="$attrs" 
          :name="name" 
          :id="id" 
          :value="value" 
          @input="updateValue($event.target.value)" 
          @keydown.space.prevent
          class="w-100" 
          :aria-required="!vEmpty && v.$params.required ? 'true' : 'false'" 
          :aria-invalid="invalid"
          :aria-describedby="ariaDescribedBy"
          />
        <span
          role="button"
          tabindex="0"
          class="fas border-0 p-0"
          :style="hidePassword ? 'background-image: url(../assets/Img/eye-regular.svg)' : 'background-image: url(../assets/Img/eye-slash-regular.svg)'"
          @keyup.enter="togglePasswordVisible"
          @click="togglePasswordVisible"
          @keydown.space.prevent="togglePasswordVisible"
          :title="libelleBoutonAfficherMotPasse">
          <span class="sr-only">{{libelleBoutonAfficherMotPasse}}</span>
        </span>
      </div>
      <span :id="idMessageErreur" class="message" v-if="message !== '' && afficherErreur && (!invalid || type !== 'nouveau')">{{ message }}</span>
    </div>

    <transition name="fade">
      <div
        v-if="type === 'nouveau' && invalid"
        :id="'pass-'+ name"
        class="d-block invalid-feedback mt-2"
        role="alert"
        aria-live="polite"
      >
        <p class="texte-validation-motdepasse">
          {{ messageVotreMotDePasseDoitContenir }}
        </p>
        <ul class="list-unstyled">
          <li class="texte-validation-motdepasse">
              <img
                :src="srcHasTenCharacters"
                class="check-valid"
                alt=""
              />
            {{ messageDixCaracteres }}
          </li>
          <li class="texte-validation-motdepasse">
              <img
                :src="srcHasUppercase"
                class="check-valid"
                alt=""
              />
            {{ messageMajuscule }}
          </li>
          <li class="texte-validation-motdepasse">
              <img
                :src="srcHasNumber"
                class="check-valid"
                alt=""
              />
            {{ messageChiffre }}
          </li>
          <li class="texte-validation-motdepasse">
              <img
                :src="srcHasSpecial"
                class="check-valid"
                alt=""
              />
            {{ messageSymbole }}
          </li>
        </ul>
      </div>
    </transition>
  </div>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";

export default {
  name: "gum-mot-de-passe-piv",
  mixins: [mixinComposantsFormulaire],
  inheritAttrs: false,
  data: function () {
    return {
      hidePassword: true
    };
  },
  methods: {
    togglePasswordVisible: function () {
      this.hidePassword = !this.hidePassword;
    },
    src(validation) {
        return validation ? '../assets/img/YES.svg' : '../assets/img/NO.svg';
    },
  },
  computed: {
    passwordType: function () {
      return this.hidePassword ? "password" : "text";
    },
    passwordsFilled: function () {
      return this.value !== "";
    },
    valid: function () {
      return (
        this.has_ten_characters &&
        this.has_uppercase &&
        this.has_number &&
        this.has_special
      );
    },
    invalid: function () {
      return this.passwordsFilled && (
        !this.has_ten_characters ||
        !this.has_uppercase ||
        !this.has_number ||
        !this.has_special
      );
    },
    messageVotreMotDePasseDoitContenir: function () {
      return this.lang === "fr-CA" ? "Pour des raisons de sécurité, votre mot de passe doit contenir au minimum :" : "For security reasons, your password must contain at least:";
    },
    messageDixCaracteres: function () {
      return this.lang === "fr-CA" ? "10 caractères" : "10 characters";
    },
    messageMajuscule: function () {
      return this.lang === "fr-CA" ? "1 majuscule" : "1 capital letter";
    },
    messageChiffre: function () {
      return this.lang === "fr-CA" ? "1 chiffre" : "1 number";
    },
    messageSymbole: function () {
      return this.lang === "fr-CA"
        ? "1 symbole ou caractère spécial (ex.: !, $, #, %)"
        : "1 symbol ou special character (eg., !, $, #, %)";
    },
    has_ten_characters() {
        return /.{10,}/.test(this.value); // From 10 to infinite characters that are not line breaks
    },
    has_uppercase() {
        return /[A-Z]+/.test(this.value); // ( isCapitalizedLetter ) One or more..
    },
    has_number() {
        return /[0-9]+/.test(this.value); // ( isNumeric ) One or more..
    },
    has_special() {
        return /[^\w\s]|[_]/.test(this.value); // !( isAlphanumeric || isWhiteSpace ) || ( isUnderscore )
    },
    srcHasTenCharacters() {
        return this.src(this.has_ten_characters);
    },
    srcHasUppercase() {
        return this.src(this.has_uppercase);
    },
    srcHasNumber() {
        return this.src(this.has_number);
    },
    srcHasSpecial() {
        return this.src(this.has_special);
    },
    idMessageErreur() {
      return `messageErreur${this.id}`;
    },
    ariaDescribedBy() {
      return this.afficherErreur ? this.idMessageErreur : false;
    },
    libelleBoutonAfficherMotPasse() {
      return this.lang === "fr-CA" ? "Afficher le mot de passe" : "Show password";
    },
  },
};
</script>
