<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import Button from '.';
	import { CommonSizes } from '$lib/types/size';
	import { Colours } from '$lib/types/colour';
	import { ButtonVariants } from '.';
	import { icons } from '$lib/components/Icon';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());

	let loading = false;

	const onClick = async () => {
		loading = true;
		const delay = new Promise((res) => setTimeout(() => res(''), 2000));

		await delay;
		loading = false;
	};
</script>

<Meta
	title="Components/Button"
	component={Button}
	argTypes={{
		colour: {
			control: 'select',
			options: getEnumValues(Colours),
		},
		iconLeft: {
			control: 'select',
			options: icons,
		},
		iconRight: {
			control: 'select',
			options: icons,
		},
		size: {
			control: 'inline-radio',
			options: getEnumValues(CommonSizes),
		},
		tooltip: {
			control: 'text',
		},
		variant: {
			control: 'inline-radio',
			options: getEnumValues(ButtonVariants),
		},
	}}
/>

<Template id="button" let:args>
	<Button {...args}>
		{args.content ?? ''}
	</Button>
</Template>

<Template
	id="loading"
	let:args
	argTypes={{
		loading: { table: { disable: true } },
	}}
>
	<Button {...args} {loading} on:click={onClick}>
		{args.content ?? ''}
	</Button>
</Template>

<Story
	name="Button"
	template="button"
	args={{
		colour: 'sky',
		content: 'Button',
		disabled: false,
		iconLeft: '',
		iconRight: '',
		loading: false,
		round: false,
		size: 'md',
		tooltip: '',
		variant: 'filled',
	}}
/>

<Story
	name="Loading"
	template="loading"
	args={{
		colour: 'sky',
		content: 'Send Message',
		disabled: false,
		iconLeft: 'PaperAirplane',
		iconRight: '',
		round: false,
		size: 'md',
		tooltip: '',
		variant: 'filled',
	}}
/>
