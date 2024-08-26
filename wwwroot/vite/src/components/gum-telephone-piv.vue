
<template>
    <div class="gum-telephone-piv" :class="{ error: afficherErreur }">
        <label :for="id" class="d-block"><span v-html="label"></span> <span class="champ-obligatoire text-danger" aria-hidden="true" v-if="!vEmpty && v.$params.required">*</span></label>
        <input ref="input"
               type="tel"
               v-bind="$attrs"
               :disabled="disabled"
               v-mask="telephoneMask"
               :name="name"
               :id="id"
               :value="value"
               :message="messageErreurTelephone"
               @input="updateValue($event.target.value)"
               @change="updateValue($event.target.value)"
               @paste="onPaste($event)"
               class="w-100"
               :aria-required="ariaRequired"
               :aria-describedby="ariaDescribedBy"
               :aria-invalid="afficherErreur" />
        <span :id="idMessageErreur" class="message" v-if="afficherErreur">{{message}}</span>
    </div>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";

export default {
  name: "gum-telephone-piv",
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