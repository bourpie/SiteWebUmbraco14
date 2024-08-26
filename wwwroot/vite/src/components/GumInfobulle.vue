<template>
    <span style="white-space: nowrap;">
        &nbsp;<button v-if="contenu !== ''"
                      @click="handleClick($event.currentTarget)"
                      type="button"
                      :data-aide="contenu"
                      :data-libelle="label"
                      :data-sansLibelle="label === '' ? true : false"
                      class="icone-info open-dialog"
                      style="display: inline; white-space: nowrap">
            <img src="../assets/img/petit_i.svg" width="16" height="16" alt="Petit i" aria-hidden="true" />
            <span class="sr-only">{{labelInfoBulle}}</span>
        </button>
    </span>
</template>

<script>
import mixinComposantsFormulaire from "./mixin-composants-formulaire.js";
export default {
    name: "gum-infobulle",
    mixins: [mixinComposantsFormulaire],
    props: {
        contenu: {
            type: String,
            default: ""
        },
        label: {
            type: String,
            default: ""
        }
    },
    computed: {
        labelInfoBulle() {
            return this.lang === "fr-CA" ? "Aide" : "Help";
        }
    },
    methods: {
        handleClick(el) {
            this.assignerContenu(el);

            this.$nextTick(() => {
                const feuille = this.$refs.feuilleModal || this.$root.$refs.feuilleModal;
                if (feuille && typeof feuille.assignContent === 'function') {
                    feuille.assignContent({
                        libelle: el.dataset.libelle,
                        aide: el.dataset.aide,
                        sansLibelle: el.dataset.sanslibelle === 'true'
                    });
                    if (typeof feuille.openModal === 'function') {
                        feuille.openModal();
                    }
                } else {
                    console.error('Feuille modal component not found or methods not defined.');
                }
            });
        },
        assignerContenu(el) {
            // Existing logic remains here
        }
    }
}
</script>

<style scoped>
button {
    background: none;
    border: none;
}
</style>
