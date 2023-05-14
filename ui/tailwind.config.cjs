/** @type {import('tailwindcss').Config} */
module.exports = {
	darkMode: ['class', '[data-mode="dark"]'],
	content: ['./src/**/*.svelte'],
	theme: {
		extend: {},
	},
	plugins: [require('@tailwindcss/typography')],
};
