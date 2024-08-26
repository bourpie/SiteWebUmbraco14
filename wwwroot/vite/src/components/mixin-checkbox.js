const mixinCheckbox = {

    data() {
        return {
            checkboxValue: this.isChecked
        }
    },
    computed: {
        isChecked() {
            return this.value;
        }
    },
    methods: {
        checkboxChanged(checked) {
            this.$emit('input', checked);
            this.$emit('change', checked);
        }
    }
}

export default mixinCheckbox;