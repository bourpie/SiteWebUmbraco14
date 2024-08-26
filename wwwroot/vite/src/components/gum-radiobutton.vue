<template>
<div  class="gum-form md-form gum-radiobutton" 
        :class="{'disabled': disabled,  'champ-trou' : this.type === 'trou'}"
        v-on:mouseover="hover = true"
        v-on:mouseleave="hover = false">
        <div 
            class="separateur-animated" 
            :class="{'active': isActive,'is-focused':isFocused, 'hovered': hover, 'checked':checked, 'erreur': afficherErreur && this.v.$invalid}">
            <input 
                    type="radio" 
                    v-bind="$attrs"
                    v-bind:name="name"
                    v-bind:id="uniqueId"
                    v-bind:value="v_value"
                    v-bind:disabled="disabled"
                    v-bind:checked="checked || value == v_value"
                    v-on:change="$emit('change',$event);$emit('input',$event.target.value)"    
                    v-on:blur="onBlur"
                    v-on:focus="onFocus"
                    v-on:focusout="onFocusout"
                    v-on:mouseover="onMouseover"
                    v-on:mouseleave="onMouseleave"               
                    v-on:click="$emit('click',$event)"
                    v-bind:aria-labelledby="'label-' + uniqueId"
                >
        <label :id="'label-' + uniqueId" :for="uniqueId">  
        <span aria-hidden="true"><span aria-hidden="true"> </span></span><div class="radio-label-text"><span v-html="label"></span><slot name="label"></slot></div></label>          
         </div>
 </div>
</template>
<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
export default {
 name:"gum-radiobutton" ,
 inheritAttrs: false,
 mixins: [mixinComposantsFormulaire],
  props: {
            checked: [Boolean, String],
            v_value: [String, Boolean]
        },
 computed:{
     
     uniqueId() {
                return this.id ? this.id : 'radio' + this._uid;
     }
 },
 methods:{
     onFocusout() {
                this.isActive = false;
                this.hover = false;
                this.isFocused = false;
                this.$emit('focusout');
            },
             onFocus() {
                this.isActive = true;
                this.hover = true;
                this.isFocused = true;
                this.$emit('focus');
            },
            onBlur() {
                this.isActive = false;
                this.isFocused = false;
                this.$emit('blur');
            },
            onMouseover() {
                this.hover = true;
                this.$emit('mouseover');
            },
            onMouseleave() {
                this.hover = false;
                this.$emit('mouseleave');
            }

 }
     
 
}
</script>
       
