
<template>
  <div class="gum-textarea">
    <div
      class="gum-form md-form mb-0"
      :class="{'disabled': disabled}"
      @mouseover="hover = true"
      @mouseleave="hover = false"
    >
      <div
        class="separateur-animated"
        :class="{'active': isActive, 'focus-out': !isActive, 'hovered': hover, 'erreur': afficherErreur && this.v.$invalid}"
      >
        <textarea
          class="md-textarea form-control"
          v-bind="$attrs"
          :maxlength="max"
          :id="id ? id : name"
          :name="name"
          :value="value"
          :disabled="disabled"
          :aria-labelledby="ariaLabelledBy"
          :aria-required="!vEmpty && v.$params.required ? 'true': 'false'"
          @blur="isActive = false"
          @focus="isActive = true; hover = true"
          @focusout="isActive = false; hover = false"
          @mouseover="hover = true"
          @mouseleave="hover = false"
          @input="autoAjustable; updateValue($event.target.value);"
          @paste="autoAjustable"
          @keyup="autoAjustable"
        ></textarea>
        <label v-if="label" :id="idLabel" :class="{'active': isActive || this.value !== ''}" :for="name">
          <span v-html="label"></span>
          <span
            v-if="estObligatoire"
            :class="{'text-danger': this.value === ''}"
            class="champ-obligatoire"
            aria-hidden="true"
          >*</span>
        </label>
      </div>
    </div>
    <span
      v-if="max !== undefined"
      :id="idNombreDeCaracteres"
      class="nbr-caracteres"
      :class="{'disabled': disabled}"
      :aria-label="nbreDeCaracteresAriaLabel"
    >{{ affichageNbreDeCaracteres }}</span>
  </div>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";

export default {
  name: "gum-textarea",
  mixins: [mixinComposantsFormulaire],
  inheritAttrs: false,
  props: {
    max: {
      type: Number,
    },
  },
  mounted() {
    this.autoAjustable();
  },
  computed: {
    estObligatoire() {
      return Object.keys(this.v).length > 0 && this.v.$params.required;
    },
    nombreDeCharactere() {
      return typeof this.value.length !== 'undefined' ? this.value.length : 0;
    },
    affichageNbreDeCaracteres() {
      return `${this.nombreDeCharactere}/${this.max}`;
    },
    idNombreDeCaracteres() {
      return `${this.name}-nbr-caracteres`;
    },
    nbreDeCaracteresAriaLabel() {
      return (this.lang === "fr-CA") ? `${this.nombreDeCharactere} sur ${this.max} caractères` : `${this.nombreDeCharactere} on ${this.max} characters`;
    },
    idLabel() {
      return `${this.name}-label`;
    },
    ariaLabelledBy() {
      return `${this.label !== '' ? this.idLabel : ''} ${this.max !== undefined ? this.idNombreDeCaracteres : ''}`.trim() || false;
    }
  },
  methods: {
    autoAjustable() {
      var el = this.$el.querySelector("textarea");
      el.style.height = "inherit";
      el.style.height = el.scrollHeight + "px";
    },
  },
  watch: {
    value() {
      var gumTextArea = this;
      Vue.nextTick(function () {
        gumTextArea.autoAjustable();
      });
    },
  },
};
</script>