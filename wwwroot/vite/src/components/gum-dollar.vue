<template>
  <gum-texte
    class="gum-dollar"
    v-bind="$attrs"
    maxlength="19"
    :mask="mask"
    :name="name"
    :label="label"
    :type="type"
    :value="value"
    :v="v"
    :disabled="disabled"
    :money="money"
    :isTypeDollar="true"
    @input="updateValue($event.replace(/\s/g,''))"
  >
  </gum-texte>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
import GumTexte from "./gum-texte.vue";

export default {
  name: "gum-dollar",
  components: {
    GumTexte,
  },
  mixins: [mixinComposantsFormulaire],
  inheritAttrs: false,
  props: {
    money: {
      type: Object,
      default: () => ({
          decimal: "",
          thousands: " ",
          precision: 0,
          masked: false,
        })
    }
  },
  methods: {
    formatValueForDecimal(value){
      let splitValue = value.split(this.money.decimal);

      // Si le montant n'a pas {precision} décimales, simuler l'entrée de {precision} zéros supplémentaires
      if(splitValue && ( splitValue.length === 1 || splitValue[1].length < 2 ))
        this.updateValue(parseFloat(value.replace(",","."))*10**this.money.precision)
    }
  },
  mounted() {
    if(this.money.precision > 0 && this.money.decimal != "") 
      this.formatValueForDecimal(this.value)

    if(this.lang !== 'fr-CA') {
      this.money.thousands = (",")
    }
  }
};
</script>