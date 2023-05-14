<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import DateTime from '.';
</script>

<Meta
	title="Components/DateTime"
	component={DateTime}
	argTypes={{
		value: {
			control: 'date',
		},
		format: {
			description: 'Example formats include: LT, LTS, L, LL, LLL, LLLL, l, ll, lll, llll',
		},
	}}
/>

<Template let:args>
	<DateTime {...args} />
</Template>

<Story name="DateTime" args={{ format: 'LLLL', value: new Date() }} />
