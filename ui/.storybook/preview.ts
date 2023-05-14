import type { Decorator, Preview } from '@storybook/svelte';
import { withThemeByDataAttribute } from '@storybook/addon-styling';
import './preview.pcss';

const preview = {
	parameters: {
		actions: { argTypesRegex: '^on:.*' },
		controls: {
			expanded: true,
			matchers: {
				color: /(background|color)$/i,
				date: /Date$/,
			},
		},
	},
} satisfies Preview;

export default preview;

const lightTheme = '☀️ Light';
const darkTheme = '🌙 Dark';

export const decorators = [
	withThemeByDataAttribute({
		themes: {
			[lightTheme]: 'light',
			[darkTheme]: 'dark',
		},
		defaultTheme: darkTheme,
		attributeName: 'data-mode',
	}),
] satisfies Decorator[];
