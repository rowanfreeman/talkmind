<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Toggle from '.';
	import { CommonSizes } from '$lib/types/size';
	import { Colours } from '$lib/types/colour';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());
</script>

<Meta
	title="Components/Form/Toggle"
	component={Toggle}
	argTypes={{
		colour: {
			control: 'select',
			options: getEnumValues(Colours),
		},
		size: {
			control: 'inline-radio',
			options: getEnumValues(CommonSizes),
		},
	}}
/>

<Template let:args>
	<Toggle {...args} />
</Template>

<Story
	name="Toggle"
	args={{
		checked: false,
		colour: 'sky',
		label: 'Toggle thing',
		size: 'md',
	}}
/>
