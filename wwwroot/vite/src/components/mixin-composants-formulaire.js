const mixinComposantsFormulaire = {

    data: function () {
        return {
            isActive: false,
            isFocused: false,
            hover: false,
            focus: false,
            lang: document.documentElement.lang,
            isIE11: null
        }
    },
    mounted() {
        this.isIE11 = !!window.MSInputMethodContext && !!document.documentMode;
    },
    props: {
        type: {
            type: String,
            default: ""
        },
        id: {
            type: String,
            default: ""
        },
        name: {
            type: String,
            default: ""
        },
        label: {
            type: String,
            default: ""
        },
        value: [String, Number, Boolean, Array, Object],
        v: {
            type: Object,
            default: function () {
                return {}
            }
        },
        message: {
            type: String,
            default: ''
        },
        labelHelper: {
            type: String,
            default: '',
          },
        disabled: [Boolean,String],
        mask: {
            type: Object,
            default: function () {
                return {
                    mask: '',
                    placeholder: ''
                }
            }
        },
        ariaDescribedby: {
            type: String
        }
    },
    computed: {

        afficherErreur: function () {
           return this.value && !this.v.validation && !this.money && this.v.$invalid;
        },
        afficherReset: function () {
            return this.isActive &&
                this.value &&
                (!this.v.$invalid || this.money /* la valeur 0 est consid�r�e invalide lorsqu'on utilise le plugin money */);
        },
        required: function() {
            return this.v.hasOwnProperty("required") && !this.v.required;
        },
        vEmpty() {
            return Object.keys(this.v).length === 0 && this.v.constructor === Object;
        },
    },
    methods: {

        resetButton: function () {
            var value = this.value;
            value = '';
            this.updateValue(value);
            this.$refs.textinput.focus();
        },

        updateValue: function (value) {
            this.$emit('input', value);
            this.$emit('change', value);
        },

        click: function(event) {
            this.$emit('click', event);
        },

        keyup: function(event) {
            this.$emit('keyup', event);
        },

        onPaste: function(event) {
            this.$emit('input', event.clipboardData.getData('text'));
            this.$emit('change', event.clipboardData.getData('text'));
        }
    }
}

export default mixinComposantsFormulaire