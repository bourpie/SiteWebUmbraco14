<template>
    <div class="gum-textbox-piv" :class="{ error: afficherErreur }">
        <label :for="id" class="d-block"><span v-html="label"></span> <span class="champ-obligatoire text-danger" aria-hidden="true" v-if="!vEmpty && v.$params.required">*</span></label>
        <input 
          ref="input" 
          type="text" 
          v-bind="$attrs" 
          :name="name" 
          :id="id" 
          :value="value" 
          @input="updateValue($event.target.value)" 
          class="w-100" 
          :aria-required="ariaRequired" 
          :aria-describedby="ariaDescribedBy"
          :aria-invalid="afficherErreur"
          />
        <span :id="idMessageErreur" class="message" v-if="afficherErreur">{{message}}</span>
    </div>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
export default {
  name: "gum-texte-piv",
  mixins: [mixinComposantsFormulaire],
  inheritAttrs: false,
  computed: {
    idMessageErreur() {
      return `messageErreur${this.id}`;
    },
    ariaDescribedBy() {
      return this.afficherErreur ? this.idMessageErreur : false;
    },
    ariaRequired() {
      return !this.vEmpty && this.v.$params.required ? 'true' : 'false';
    }
  }
};
</script>
