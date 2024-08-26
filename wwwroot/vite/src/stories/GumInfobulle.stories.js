import Infobulle from '../components/gum-texte-piv.vue';

// More on how to set up stories at: https://storybook.js.org/docs/writing-stories
export default {
  title: 'Example/Infobulle',
  component: Infobulle,
  tags: ['autodocs'],
};

// More on writing stories with args: https://storybook.js.org/docs/writing-stories/args
export const Primary = {
  args: {
    label: 'Button',
    labelHelper: 'Button',
    value: ''
  },
};
