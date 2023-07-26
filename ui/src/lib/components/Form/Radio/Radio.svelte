<script lang="ts">
	import type { CommonSize } from '$lib/types/size';
	import Text, { type TextSize } from '$lib/components/Text';
	import { useRadioGroupContext } from '.';

	type TValue = $$Generic;

	interface $$Props {
		label?: string;
		name?: string;
		value: TValue;
	}

	export let label: $$Props['label'] = '',
		name: $$Props['name'] = '',
		value: $$Props['value'];

	const context = useRadioGroupContext<TValue>();
	let { colour, name: groupName, selected, size } = context;

	$: textSize = {
		xs: 'xs',
		sm: 'sm',
		md: 'base',
		lg: 'lg',
		xl: 'xl',
	} satisfies Record<CommonSize, TextSize>;
</script>

<label for={name || label} class="flex items-center gap-2 cursor-pointer">
	<span class="relative flex items-center">
		<input
			class="appearance-none aspect-square h-full dark:bg-neutral-100/10 bg-neutral-900/10 rounded-full dot cursor-[inherit]"
			class:w-3={$size === 'xs'}
			class:w-4={$size === 'sm'}
			class:w-5={$size === 'md'}
			class:w-8={$size === 'lg'}
			class:w-12={$size === 'xl'}
			class:border={$size === 'xs' || $size === 'sm'}
			class:border-2={$size === 'md' || $size === 'lg' || $size === 'xl'}
			class:checked:after:bg-amber-500={$colour === 'amber'}
			class:checked:after:bg-blue-500={$colour === 'blue'}
			class:checked:after:bg-cyan-500={$colour === 'cyan'}
			class:checked:after:bg-emerald-500={$colour === 'emerald'}
			class:checked:after:bg-fuchsia-500={$colour === 'fuchsia'}
			class:checked:after:bg-green-500={$colour === 'green'}
			class:checked:after:bg-indigo-500={$colour === 'indigo'}
			class:checked:after:bg-lime-500={$colour === 'lime'}
			class:checked:after:bg-orange-500={$colour === 'orange'}
			class:checked:after:bg-pink-500={$colour === 'pink'}
			class:checked:after:bg-purple-500={$colour === 'purple'}
			class:checked:after:bg-red-500={$colour === 'red'}
			class:checked:after:bg-rose-500={$colour === 'rose'}
			class:checked:after:bg-sky-500={$colour === 'sky'}
			class:checked:after:bg-teal-500={$colour === 'teal'}
			class:checked:after:bg-violet-500={$colour === 'violet'}
			class:checked:after:bg-yellow-500={$colour === 'yellow'}
			class:border-amber-500={$colour === 'amber'}
			class:border-blue-500={$colour === 'blue'}
			class:border-cyan-500={$colour === 'cyan'}
			class:border-emerald-500={$colour === 'emerald'}
			class:border-fuchsia-500={$colour === 'fuchsia'}
			class:border-green-500={$colour === 'green'}
			class:border-indigo-500={$colour === 'indigo'}
			class:border-lime-500={$colour === 'lime'}
			class:border-orange-500={$colour === 'orange'}
			class:border-pink-500={$colour === 'pink'}
			class:border-purple-500={$colour === 'purple'}
			class:border-red-500={$colour === 'red'}
			class:border-rose-500={$colour === 'rose'}
			class:border-sky-500={$colour === 'sky'}
			class:border-teal-500={$colour === 'teal'}
			class:border-violet-500={$colour === 'violet'}
			class:border-yellow-500={$colour === 'yellow'}
			type="radio"
			id={name || label}
			{value}
			name={$groupName}
			on:change={() => ($selected = value)}
		/>
	</span>
	<Text element="span" class="select-none" size={textSize[$size ?? 'md']}>{label || name}</Text>
</label>

<style lang="postcss">
	.dot {
		@apply checked:after:content-[''] checked:after:absolute checked:after:inset-0 checked:after:rounded-full checked:after:scale-50 after:transition-colors;
	}
</style>
