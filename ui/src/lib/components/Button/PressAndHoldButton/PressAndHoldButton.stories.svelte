<script lang="ts">
	import { Meta, Story, Template } from '@storybook/addon-svelte-csf';
	import PressAndHoldButton from '.';
	import { CommonSizes } from '$lib/types/size';

	const getEnumValues = (obj: Record<string, unknown>) =>
		Object.values(obj)
			.filter((x) => isNaN(Number(x)))
			.map((x) => `${x}`.toLocaleLowerCase());

	let message = 'Press and Hold';
	let releaseTimeout: number | undefined = undefined;

	const handleHold = () => {
		clearTimeout(releaseTimeout);
		message = 'Holding';
	};
	const handleRelease = () => {
		message = 'Released';

		releaseTimeout = window?.setTimeout(() => (message = 'Press and Hold'), 1000);
	};
</script>

<Meta
	title="Components/Button/PressAndHoldButton"
	component={PressAndHoldButton}
	argTypes={{
		size: {
			control: 'inline-radio',
			options: getEnumValues(CommonSizes),
		},
	}}
/>

<Template let:args>
	<PressAndHoldButton {...args} on:hold={handleHold} on:release={handleRelease}>
		{message}
	</PressAndHoldButton>
</Template>

<Story
	name="PressAndHoldButton"
	args={{ disabled: false, keyCode: 'Space', round: true, size: 'md' }}
/>
