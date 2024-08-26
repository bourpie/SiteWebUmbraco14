<template>
    <span style="white-space: nowrap;">&nbsp;<button v-if="contenu != ''"
                @click="assignerContenu($event.currentTarget)"
                data-toggle="modal"
                data-target="#gum-modal"
                type="button"
                :data-aide="contenu"
                :data-libelle="label"
                :data-sansLibelle="label === '' ? true : false"
                class="icone-info open-dialog"
                style="display: inline; white-space: nowrap">
            <img src="../assets/Img/petit_i.svg" width="16" height="16" alt="Petit i" aria-hidden="true" />
            <span class="sr-only">{{labelInfoBulle}}</span>
        </button>
    </span>
</template>
<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
export default {
 name:"gum-infobulle" ,
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

            if (this.eventlabelga !== "") {
                dataLayer.push({
                    "event": "uaevent",
                    "eventCategory": "account",
                    "eventAction": "tooltip",
                    "eventLabel": this.eventlabelga
                });
            }
        }
    }  
 
}
</script>
       
