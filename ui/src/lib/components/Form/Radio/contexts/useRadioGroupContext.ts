import { getContext } from 'svelte';
import type { Readable, Writable } from 'svelte/store';
import type { CommonSize } from '$lib/types/size';
import type { Colour } from '$lib/types/colour';

export interface RadioGroupContext<TValue> {
	colour: Readable<Colour>;
	name: Readable<string>;
	selected: Writable<TValue | undefined>;
	size: Readable<CommonSize>;
}

const useRadioGroupContext = <TValue>() =>
	getContext<RadioGroupContext<TValue>>('RadioGroupContext');

export default useRadioGroupContext;
