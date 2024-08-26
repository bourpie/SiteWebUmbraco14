<template>
<div 
        class="gum-radio-et-phrase-trou"
        v-bind:class="{'hovered':hover, 'checked': checked || value == v_value, 'disabled': disabled}"
                @mouseover="hover = true"
                @mouseleave="hover = false">
        <GumRadiobutton
                class="form-check-inline"
                :disabled="disabled"
                :id="id"
                :name="name"
                :label="label"
                :v_value="v_value"
                :value="value"
                :v="v"
                @click="$emit('click',$event);"
                @input="$emit('input',$event);"
                @focus="focus = true"
        >
          <template v-slot:label>
              <slot></slot>
          </template>
        </GumRadiobutton>   
    </div>
</template>
<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
import GumRadiobutton from './gum-radiobutton.vue'
export default {
 name:"gum-radio-trou" ,
 inheritAttrs: false,
 mixins: [mixinComposantsFormulaire],
  props: {
checked: {
            type: Boolean,
            default: false
        },
        v_value: [String, Boolean]
        },        
  components: {
    GumRadiobutton
  }
 }  
</script>
       
