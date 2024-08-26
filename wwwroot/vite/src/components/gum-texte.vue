<template>
  <div
    class="gum-form md-form gum-texte"
    :class="{
      disabled: disabled,
      'champ-trou': this.type === 'trou',
      erreur: afficherErreur && this.v.$invalid,
      'focus-out': !focus,
    }"
    @mouseover="hover = true"
    @mouseleave="hover = false"
  >
    <div
      class="separateur-animated w-100"
      :class="{
        active: isActive,
        hovered: hover,
        erreur: afficherErreur && this.v.$invalid,
      }"
    >
      <span
        v-if="this.lang === 'en-CA' && isTypeDollar"
        class="devise devise-en"
        >$</span
      >
      <div v-if="type === 'trou'" class="hidden-size-indicator">{{sizeIndicator}}</div>
      <input
        ref="textinput"
        class="form-control mb-0"
        v-bind="$attrs"
        :class="{ empty: this.value === '', 'not-empty': this.value !== '' }"
        :id="name"
        :name="name"
        :value="value"
        v-money="money"
        :disabled="disabled"
        :aria-describedby="ariaDescribedby"
        :aria-required="!vEmpty && v.$params.required ? 'true': 'false'"
        v-mask="mask"
        @input="updateValue($event.target.value)"
        @blur="
          updateValue($event.target.value);
          isActive = false;
        "
        @focus="
          isActive = true;
          (hover = true), (focus = true);
        "
        @focusout="
          isActive = false;
          (hover = false), (focus = false);
        "
        @mouseover="hover = true"
        @mouseleave="hover = false"
        @click="click($event)"
        @keyup="keyup($event)"
      />
      <label
        :class="{
          active: isActive || (this.value && this.value !== ''),
          'text-danger': afficherErreur,
        }"
        :for="name"
      >
          <span v-html="label"></span>
          <span
            v-if="!vEmpty && v.$params.required"
            class="champ-obligatoire text-danger"
            aria-hidden="true"
            >*</span>
      </label>
      <transition name="fade" mode="out-in">
        <button
          type="button"
          v-if="type !== 'trou'"
          v-show="afficherReset"
          class="button-unstyled button-input-reset"
          @click.prevent="resetButton"
        >
          <span class="sr-only">{{ libelleVideChamps }}</span>
          <img
            src="../assets/img/icone-supprimer.svg"
            width="16"
            height="16"
            aria-hidden="true"
            :alt="libelleVideChamps"
          />
        </button>
      </transition>
      <transition name="fade" mode="out-in">
        <img
          v-if="afficherErreur"
          class="icone-erreur"
          src="../assets/img/icone-erreur.svg"
          width="16"
          height="16"
          aria-hidden="true"
          alt="Erreur"
        />
      </transition>

      <span
        v-if="this.lang === 'fr-CA' && isTypeDollar"
        class="devise devise-fr"
        >$</span
      >
    </div>

    <div class="label-aide" v-if="labelHelper">
      {{ labelHelper }}
    </div>
    
    <transition name="fade">
      <div v-if="afficherErreur" class="erreur invalid-feedback">
        {{ message }}
      </div>
    </transition>
  </div>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
export default {
  name: "gum-texte",
  mixins: [mixinComposantsFormulaire],
  inheritAttrs: false,
  mounted() {
    // Hack pour détection crossbrowser du autocomplete (change n'est pas déclenché sur la plupart des browsers)
    let input = this.$el.querySelector("input");
    window.setInterval(() => {
      if (input.value && input.value.length > 0) this.updateValue(input.value);
    }, 250);
  },
  props: {
    isTypeDollar: {
      type: Boolean,
      default: false,
    },
    money: {
      type: Object
    }
  },
  computed: {
    libelleVideChamps() {
      return this.lang === "fr-CA" ? "Vider le champs" : "Clear value";
    },
    sizeIndicator() {
      if(this.label.length > this.mask.placeholder.length)
        return !this.vEmpty && this.v.$params.required ? this.label + ' *': this.label;
      else
        return this.mask.placeholder;
    }
  },
};
</script>

<style>
</style>
