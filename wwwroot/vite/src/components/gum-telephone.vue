
<template>
  <GumTexte   class="gum-telephone"
                    v-bind="$attrs"
                    :mask="telephoneMask" 
                    :message="messageErreurTelephone" 
                    :name="name" 
                    :label="label" 
                    :type="type" 
                    :value="value" 
                    :v="v"
                    :disabled="disabled"                   
                    @input="updateValue($event)">
</GumTexte>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
import GumTexte from "./gum-texte.vue";

export default {
  name: "gum-telephone",
  components: {
      GumTexte
  },
  mixins: [mixinComposantsFormulaire],
  inheritAttrs: false,
  computed: {
 telephoneMask() {
            return { mask: '999 999-9999', placeholder: 'XXX XXX-XXXX' }
        },
        messageErreurTelephone: function () {
            return this.lang === "fr-CA" ? "Le format du numéro de téléphone est invalide." : "Telephone number format is not valid.";
        }
  },
};
</script>