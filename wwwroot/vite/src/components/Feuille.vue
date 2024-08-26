<template>
    <div v-if="isVisible" id="gum-modal" class="feuille modal-aide" tabindex="-1" role="dialog" aria-labelledby="modal-title">
      <div class="modal-header" id="modal-header">
        <button type="button" class="close" @click="closeModal">
          <svg version="1.1" id="Calque_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 16 16" style="enable-background:new 0 0 16 16;" xml:space="preserve">
            <path id="_0811-cross" class="st0" d="M8.9,8l6.9-6.9c0.2-0.2,0.2-0.6,0-0.9c-0.2-0.2-0.6-0.2-0.9,0L8,7.1L1.1,0.2c-0.2-0.2,0.6-0.2,0.9,0s-0.2,0.6,0,0.9L7.1,8l-6.9,6.9c-0.2,0.2-0.2,0.6,0,0.9c0.2,0.2,0.6,0.2,0.8,0L8,8.9l6.9,6.9c0.2,0.2,0.6,0.2,0.9,0c0.2-0.2,0.2-0.6,0-0.8L8.9,8L8.9,8z"/>
          </svg>
          <span class="sr-only">@Umbraco.GetDictionaryValue("Action.Fermer")</span>
        </button>
        <div id="modal-title" class="h1">
          <span class="sr-only">@Umbraco.GetDictionaryValue("Titre.AideApropos")</span>
          <span>{{ modalTitle }}</span>
        </div>
      </div>
      <div class="modal-content">
        <div class="modal-body">
          <div class="dialog-content">{{ modalContent }}</div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'Feuille',
    data() {
      return {
        isVisible: false,
        modalTitle: '',
        modalContent: ''
      };
    },
    methods: {
      openModal() {
        this.isVisible = true;
      },
      closeModal() {
        this.isVisible = false;
      },
      assignContent({ libelle, aide, sansLibelle }) {
        this.modalTitle = sansLibelle ? '' : libelle;
        this.modalContent = aide;
      }
    }
  };
  </script>
  
  <style scoped>
  .modal {
    position: fixed;
    bottom: 0;
    left: 0;
    width: 100%;
    max-height: 70%;
    background-color: white;
    border-radius: 8px 8px 0 0;
    box-shadow: 0 -2px 10px rgba(0, 0, 0, 0.2);
    transform: translateY(100%);
    transition: transform 0.3s ease-in-out;
  }
  .modal.feuille {
    transform: translateY(0);
  }
  .modal-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 16px;
  }
  .modal-body {
    padding: 16px;
  }
  .close {
    background: none;
    border: none;
    font-size: 24px;
  }
  </style>
  