<script lang="ts">
	import { RadioGroupContextProvider } from '.';
	import type { CommonSize } from '$lib/types/size';
	import type { Colour } from '$lib/types/colour';

	type TValue = $$Generic;

	interface $$Props {
		colour?: Colour;
		label?: string;
		name: string;
		size?: CommonSize;
		value?: TValue;
	}

	export let colour: $$Props['colour'] = 'sky',
		label: $$Props['label'] = '',
		name: $$Props['name'] = '',
		size: $$Props['size'] = 'md',
		value: $$Props['value'] = undefined;
</script>

<RadioGroupContextProvider {colour} {name} {size} bind:value>
	<fieldset
		class="flex flex-col"
		class:gap-1={size === 'xs' || size === 'sm'}
		class:gap-2={size === 'md' || size === 'lg' || size === 'xl'}
	>
		<legend>{label}</legend>
		<slot />
	</fieldset>
</RadioGroupContextProvider>
