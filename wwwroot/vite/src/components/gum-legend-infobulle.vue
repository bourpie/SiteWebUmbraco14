<template>
    <legend class="gum-legend-infobulle">
        <span v-html="label"></span>&nbsp;<span v-if="!vEmpty && v.$params.required" class="champ-obligatoire text-danger">*</span>&nbsp;<GumInfoBulle v-if="contenu" :contenu="contenu" :eventlabelga="eventlabelga"></GumInfoBulle>
    </legend>
</template>
<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
import GumInfoBulle from './gum-infobulle.vue'
export default {
 name:"gum-legend-infobulle" ,
 inheritAttrs: false,
 mixins: [mixinComposantsFormulaire],
  props: {
        contenu: {
            type: String,
            default: ""
        },
        // Si renseigné un dataLayer.push sera effectué à l'affichage de l'info-bulle.
        eventlabelga: {
            type: String,
            default: ""
        }
    },
 computed:{
     labelInfoBulle() {
            return this.lang === "fr-CA" ? "Aide" : "Help";
        },
        vEmpty() {
            return Object.keys(this.v).length === 0 && this.v.constructor === Object
        }
 } ,
 
    methods: {
         assignerContenu(el) {
            var libelle = document.getElementById("dialog-title");
            var aide = document.getElementById("dialog-description");
            var modalHeader = document.getElementById("modal-header");
            if (el.dataset.sanslibelle) {
                modalHeader.classList.add("modal-header-sansLibelle");
            } else {
                libelle.innerHTML = el.dataset.libelle;
            }
            aide.innerHTML = el.dataset.aide;
        }
    }  ,
     components: {
   GumInfoBulle
  }
 
}
</script>
       
