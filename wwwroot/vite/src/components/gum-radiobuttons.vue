<template>
 <fieldset class="gum-radiobuttons">
        <GumLegendInfobulle
            v-if="showLegend"
            :label="label"
            :v="v"
            :contenu="contenuInfoBulle"
            :eventlabelga="eventLabelGaInfoBulle"
            >
        </GumLegendInfobulle>
        <p v-if='text'>
            <span class="form-text">{{text}}</span>
        </p>
        <GumRadiobutton
                v-for="(radio,index) in formatedRadios"
                :class="{'form-check-inline' : orientation === 'inline'}"
                :key="index"
                :id="radio.id"
                :name="name"
                :data-test="radio.dataTest"
                :label="radio.label"
                :v_value="radio.value"
                :v="v"
                :checked="radio.checked"
                v-on:change="updateValue($event.target.value);"
        >
        </GumRadiobutton>
    </fieldset>
</template>
<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
import GumLegendInfobulle from './gum-legend-infobulle.vue'
import GumRadiobutton from './gum-radiobutton.vue'
export default {
 name:"gum-radiobuttons" ,
 inheritAttrs: false,
 mixins: [mixinComposantsFormulaire],
  props: {
        radios: {
            type: Array,
            default: []
        },
        contenuInfoBulle: {
            type: String,
            default: ""
        },
        // Si renseigné un dataLayer.push sera effectué à l'affichage de l'info-bulle.
        eventLabelGaInfoBulle: {
            type: String,
            default: ""
        },
        orientation: {
            type: String,
            default: "vertical"
        },
        text: {
            type: String,
            default: ""
        }
    },
 computed:{
     
      formatedRadios() {
              return this.radios.map(function(radio) {
                radio["id"] = this.name + "-" + radio.value;
                radio["checked"] = this.value === radio.value;
                radio["dataTest"] = this.attrs && this.attrs['data-test'] ? this.attrs['data-test'] + '-' + radio.value : radio["id"];  
                return radio;
            }.bind(this));
        },
        showLegend() {
            return this.label || this.contenuInfoBulle;
        }
 },
  components: {
    GumLegendInfobulle,
     GumRadiobutton
  }   
 
}
</script>
       
