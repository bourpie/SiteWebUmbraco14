
<template>
  <gum-texte
    class="gum-date"
    v-bind="$attrs"
    :mask="dateMask"
    :message="messageErreurDate"
    :name="name"
    :label="label"
    :type="type"
    :value="value"
    :v="v"
    :disabled="disabled"
    @click="click($event)"
    @input="updateValue($event)"
  ></gum-texte>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
import GumTexte from "./gum-texte.vue";

export default {
  name: "gum-date",
  components: {
      GumTexte
  },
  mixins: [mixinComposantsFormulaire],
  inheritAttrs: false,
  computed: {
    dateMask() {
      if (this.lang === "fr-CA") {
        return { mask: "9999-99-99", placeholder: "AAAA-MM-JJ" };
      } else {
        return { mask: "9999-99-99", placeholder: "YYYY-MM-DD" };
      }
    },
    messageErreurDate() {
      return this.message && this.message !== "" 
        ? this.message
        : this.lang === "fr-CA"
            ? "Le format de la date est invalide."
            : "Date format is not valid.";
    },
  },
};
</script>