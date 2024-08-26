<template>
<div 
    class="gum-form md-form gum-select" 
    v-bind:class="{'disabled': disabled, 'champ-trou': type === 'trou', 'focus-out': !focus, erreur: afficherErreur && this.v.$invalid}"
    v-on:mouseover="hover = true"
    v-on:mouseleave="hover = false">

    <div class="hidden-largest-element vs__selected-options" aria-hidden="true">{{longestOption}}</div>

    <div 
        class="separateur-animated"
        :style="{'width': width+'px'}"
        v-bind:class="{'active': isActive, 'hovered': hover, 'erreur': afficherErreur && this.v.$invalid, 'is-open': isOpen}">

            <label 
                v-if="isIE11 === false"
                :id="name + '-label'"
                v-bind:class="{'active': isActive || !estVide, 'text-danger': afficherErreur}"
                v-bind:for="name">
                <span v-html="label"></span>
                <span
                    v-if="estObligatoire"
                    v-bind:class="{'text-danger': this.value === ''}"
                    class="champ-obligatoire"
                    aria-hidden="true" >
                    *
                </span>
            </label>

            <select
            v-if="isIE11" 
            :disabled="disabled"
            :value="value" 
            :name="name" 
            v-on:input="updateValue($event.target.value)"
            class="form-control">
               <option value="">{{label}}</option>
               <option v-for="option in options" :value="option.code" :key="option.code">{{option.label}}</option>
           </select>

           <input 
                v-if="isIE11 === false"
                type="hidden" 
                :value="value" 
                :name="name" 
                v-on:input="updateValue($event.target.value)"
            />

          <v-select 
                ref="v-select"
                v-if="isIE11 === false"
                v-bind="$attrs"
                class="style-chooser"
                transition="fade"
                :disabled="disabled"
                :options="options"
                :value="selectedOption"
                :clearable="false"
                :searchable="false"
                :filterable="false"
                @input="onInput($event)"
                @search:focus="isOpen = true"
                @search:blur="isOpen = false"
                >
                <template #search="{ attributes, events }">
                  <input
                    readonly
                    class="vs__search"
                    v-bind="attributes"
                    v-on="events"
                    :aria-labelledby="name + '-label'"
                    :aria-required="!vEmpty && v.$params.required ? 'true': 'false'"
                  >
                </template>
                <template #open-indicator="{ attributes }">
                  <span v-bind="attributes">
                    <img class="icone-dropdown" src="../assets/img/icone_down.svg" alt="" width="16" height="8" />
                  </span>
                </template>
           </v-select>
    </div>
</div> 
</template>
<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
export default {
    inheritAttrs: false,
    mixins: [mixinComposantsFormulaire],
    data() {
        return {
            uniqueId: null,
            attributes: {
                'ref': 'openIndicator',
                'role': 'presentation',
                'class': 'vs__open-indicator'
            },
            events: {
                'blur': this.blur,
                'focus': this.onSearchFocus,
            },
            obligatoire: false,
            isOpen: false,
            width:0

        }
    },
    mounted() {  
        this.width = this.$el.getElementsByClassName('hidden-largest-element')[0].clientWidth + 50;
        this.$nextTick(function () {
            if (this.selectedOption !== undefined) {
                this.setAriaLabel(this.selectedOption.code)
            }
        })
    },
    props: {
        options: {
            type: Array,
            required: true
        },
        selected: {
            type: String
        }
    },
    computed: {
        estObligatoire() {
            return (this.v !== undefined && this.v.$params !== undefined && this.v.$params.required) || this.obligatoire;
        },
        estVide() {
            return !this.value || 0 === this.value.length
        },
        longestOption() {
            var longestOption = this.options.reduce(function(a, b) { return a.label.length > b.label.length ? a : b; });
            
            if(this.value) return longestOption.label;

            return longestOption.label.length > this.label.length ? longestOption.label : this.label; 
        },
        selectedOption() {
            return typeof this.value === "object" ? this.value : this.getOption(this.value)
        }
    },
    methods: {
        onInput($event) {
            this.setAriaLabel($event)
            this.updateValue($event)
        },
        setAriaLabel(code){
            this.$refs["v-select"].$refs["toggle"].setAttribute("aria-label", `${this.lang === "fr-CA" ? "Sélectionné" : "Selected"} ${this.getOption(code).label}`)
        },
        getOption(code) {
            return this.options.filter(o => o.code == code)[0]
        }
    }
}
</script>

<style>

</style>