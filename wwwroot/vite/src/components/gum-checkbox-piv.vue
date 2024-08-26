<template>
    <div class="gum-checkbox-piv">
        <input type="checkbox"
            v-bind="$attrs"  
            :name="name" 
            :id="id" 
            :value="value" 
            :checked="value" 
            :disabled="disabled" 
            :data-test="'checkbox' + name" 
            @change="updateValue($event.target.checked);"
            >
        <label class="m-0" :for="id"><span v-html="label"></span><span class="champ-obligatoire text-danger" aria-hidden="true" v-if="!vEmpty && v.$params.required">*</span></label>
    </div>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
export default {
    name: 'gum-checkbox-piv',
    mixins: [mixinComposantsFormulaire],
    inheritAttrs: false,
}
</script>