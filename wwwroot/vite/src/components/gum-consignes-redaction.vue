<template>
  <div class="gum-consignes-redaction boite boite-information" :class="data.staticClass || ''" v-bind="$attrs">
    <div class="boite-titre d-flex">
      <img src="../assets/img/icone_information_alert.svg" alt="" aria-hidden="true" />
      <strong v-if="props.titre" class="titre mb-0 ml-3"><span v-html="props.titre"></span></strong>
    </div>
    <div class="boite-contenu">
      <ul v-if="props.consignes && props.consignes.length > 0">
        <li v-for="(consigne, index) in props.consignes" :key="`consigne-${index}`" v-html="consigne"></li>
      </ul>
      <slot></slot>
    </div>
  </div>
</template>
<script>
export default {
  name: "gum-consignes-redaction", 
  props: {
    titre: {
      type: String,
      default: "",
    },
    consignes: {
      type: Array,
      default: () => [],
    },
  },
};
</script>