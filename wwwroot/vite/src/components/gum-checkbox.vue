<template>
  <label
    v-on:mouseover="hover = true"
    v-on:mouseleave="hover = false"
    class="gum-custom-checkbox" 
    :class=" {'disabled': disabled, 'is-checked':isChecked, 'is-hovered':hover, 'is-focused':isFocused}" :for="name">
    <span class="label" v-html="label"> </span>
    <input 
            type="checkbox" 
            v-bind="$attrs"
            v-bind:id="name"
            v-bind:name="name"
            v-bind:value="value"
            v-bind:disabled="disabled"
            v-on:change="checkboxChanged($event.target.checked);"
            v-on:blur="isFocused = false"
            v-on:focus="isFocused = true;"
            v-on:focusout="isFocused = false;"
            v-on:mouseover="hover = true"
            v-on:mouseleave="hover = false"
            v-bind:checked="value"
        >
        <input type="hidden" :value="value" :name="name" />

        <transition name="fade"><span v-if="hover || isChecked" class="checkmark">
            <svg xmlns="http://www.w3.org/2000/svg" width="14.409" height="11.42" viewBox="0 0 14.409 11.42">
                <g transform="translate(-2.04 -3.79)">
                    <path class="a" d="M7.541,13.48,4.459,10.37,3.41,11.421,7.541,15.59,16.41,6.641,15.368,5.59Z" transform="translate(-0.665 -1.09)"/>
                </g>
            </svg>
        </span></transition>
    </label>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
import mixinCheckbox from "./mixin-checkbox.js"
export default {
    name: 'gum-checkbox',
    mixins: [mixinComposantsFormulaire, mixinCheckbox],
    inheritAttrs: false,
}
</script>