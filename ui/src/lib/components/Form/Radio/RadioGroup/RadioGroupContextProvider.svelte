<script lang="ts">
	import { setContext } from 'svelte';
	import { readonly, writable } from 'svelte/store';
	import type { RadioGroupContext } from '.';
	import type { CommonSize } from '$lib/types/size';
	import type { Colour } from '$lib/types/colour';

	type TValue = $$Generic;

	interface $$Props {
		colour?: Colour;
		name: string;
		size?: CommonSize;
		value?: TValue;
	}

	export let colour: $$Props['colour'] = 'sky',
		name: $$Props['name'],
		size: $$Props['size'] = 'md',
		value: $$Props['value'] = undefined;

	const selected = writable(value);

	const colourStore = writable(colour);
	const nameStore = writable(name);
	const sizeStore = writable(size);

	selected.subscribe((x) => (value = x));
	const context = {
		colour: readonly(colourStore),
		name: readonly(nameStore),
		selected,
		size: readonly(sizeStore),
	} satisfies RadioGroupContext<TValue>;

	setContext<RadioGroupContext<TValue>>('RadioGroupContext', context);

	$: {
		colourStore.set(colour ?? 'sky');
	}

	$: {
		nameStore.set(name);
	}

	$: {
		sizeStore.set(size ?? 'md');
	}
</script>

<slot />
