<template>
  <div
    class="alert alert-dismissible"
    role="alert"
    :class="[typealerte, {messageVisible : messageVisible}]"
    v-show="messageVisible"
  >
    <button
      v-if="label !== undefined"
      @click.prevent="creercookie"
      type="button"
      class="close"
      data-dismiss="alert"
      :aria-label="label"
    >
      <svg version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
        viewBox="0 0 16 16" style="enable-background:new 0 0 16 16;" xml:space="preserve">
      <path class="st0" d="M8.9,8l6.9-6.9c0.2-0.2,0.2-0.6,0-0.9c-0.2-0.2-0.6-0.2-0.9,0L8,7.1L1.1,0.2
        c-0.2-0.2-0.6-0.2-0.9,0s-0.2,0.6,0,0.9L7.1,8l-6.9,6.9c-0.2,0.2-0.2,0.6,0,0.9c0.2,0.2,0.6,0.2,0.8,0L8,8.9l6.9,6.9
        c0.2,0.2,0.6,0.2,0.9,0c0.2-0.2,0.2-0.6,0-0.8L8.9,8L8.9,8z"/>
      </svg>
      <span class="sr-only" v-html="lang === 'fr-CA' ? 'Fermer' : 'Close'"></span>
    </button>
    <div :class="containerClass">
      <p v-if="icone" class="icone">
        <img :src="icone" alt aria-hidden="true" width="24" height="24" />
      </p>
      <slot></slot>
    </div>
  </div>
</template>

<script>
export default {
  name: "gum-message",
  data() {
    return {
      messageVisible: true,
      lang: document.documentElement.lang,
    };
  },
  mounted() {
    this.toggleBodyClass();
  },
  computed: {
    containerClass() {
      return this.icone === ""
        ? "container text-center"
        : "container text-left";
    },
  },
  props: {
    titre: {
      type: String,
    },
    typealerte: {
      type: String,
      required: true,
    },
    label: {
      type: String,
    },
    neplusafficher: String,
    nomcookie: String,
    valeurcookie: String,
    icone: String,
  },
  methods: {
    creercookie() {
      this.messageVisible = false;
      if (this.neplusafficher === "true") {
        document.cookie =
          this.nomcookie + "=" + this.valeurcookie + "; path=/;";
      }
      this.toggleBodyClass();
    },
    toggleBodyClass() {
      var el = document.body;
      var className = "composante-message-operationnel";

      if (this.messageVisible === true) {
        el.classList.add(className);
      } else {
        el.classList.remove(className);
      }
    },
  },
};
</script>
