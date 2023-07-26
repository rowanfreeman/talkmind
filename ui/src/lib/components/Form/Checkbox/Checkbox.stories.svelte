<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Checkbox from '.';
	import { CommonSizes } from '$lib/types/size';
	import { Colours } from '$lib/types/colour';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());
</script>

<Meta
	title="Components/Form/Checkbox"
	component={Checkbox}
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
	<Checkbox {...args} />
</Template>

<Story
	name="Checkbox"
	args={{
		checked: false,
		colour: 'sky',
		indeterminate: false,
		label: 'I agree',
		size: 'md',
	}}
/>
