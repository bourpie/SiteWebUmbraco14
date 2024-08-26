<template>
  <div class="gum-commutateur" :class="{'is-active': this.value}">
    <button type="button"
            role="switch"
            v-bind="$attrs"
            v-bind:id="id"
            v-bind:name="name"
            v-bind:disabled="disabled" 
            @click="toggleSwitch()"
            :aria-checked="value.toString()"
            :aria-label="label"
            :data-test="'commutateur' + id">
      <span class="bouton"></span>
    </button>
  </div>
</template>

<script>
  import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
  export default {
      name: 'gum-commutateur',
      mixins: [mixinComposantsFormulaire],
      inheritAttrs: false,
      props: {
        value: {
          type: Boolean,
          default: false
        }
      },
      methods: {
          toggleSwitch() {
            this.$emit('input', !this.value);            
          }
      }
  }
</script>