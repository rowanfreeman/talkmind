<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Radio, { RadioGroup } from '.';
	import Text from '$lib/components/Text';
	import { CommonSizes } from '$lib/types/size';
	import { Colours } from '$lib/types/colour';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());

	let value = '';
</script>

<Meta
	title="Components/Form/Radio"
	component={Radio}
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
	<RadioGroup {...args} bind:value>
		<Radio label="Red" value="red" />
		<Radio label="Green" value="green" />
		<Radio label="Blue" value="blue" />
		<Radio label="Yellow" value="yellow" />
	</RadioGroup>
	{#if value}
		<Text>You have chosen: {value}</Text>
	{/if}
</Template>

<Story
	name="Radio"
	args={{
		colour: 'sky',
		label: 'What is your favourite colour?',
		name: 'colour',
		size: 'md',
		value,
	}}
/>
