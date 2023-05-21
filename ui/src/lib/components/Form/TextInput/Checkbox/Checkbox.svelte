<script lang="ts">
	import { scale } from 'svelte/transition';

	import type { CommonSize } from '$lib/types/size';
	import type { Colour } from '$lib/types/colour';
	import Text, { type TextSize } from '$lib/components/Text';
	import Icon from '$lib/components/Icon';

	interface $$Props {
		checked?: boolean;
		colour?: Colour;
		indeterminate?: boolean;
		label?: string;
		size?: CommonSize;
	}

	export let checked: $$Props['checked'] = false,
		colour: $$Props['colour'] = 'sky',
		indeterminate: $$Props['indeterminate'] = false,
		label: $$Props['label'] = '',
		size: $$Props['size'] = 'md';

	$: textSize = {
		xs: 'xs',
		sm: 'sm',
		md: 'base',
		lg: 'lg',
		xl: 'xl',
	} satisfies Record<CommonSize, TextSize>;
</script>

<label class="flex items-center gap-2 cursor-pointer select-none">
	<span class="relative flex items-center text-neutral-100">
		<input
			type="checkbox"
			on:change
			class="appearance-none aspect-square rounded cursor-pointer transition-colors duration-100"
			class:w-3={size === 'xs'}
			class:w-4={size === 'sm'}
			class:w-5={size === 'md'}
			class:w-8={size === 'lg'}
			class:w-12={size === 'xl'}
			class:border={['xs', 'sm'].includes(size ?? 'md')}
			class:border-2={['md', 'lg', 'xl'].includes(size ?? 'md')}
			class:bg-amber-500={(checked || indeterminate) && colour === 'amber'}
			class:bg-blue-500={(checked || indeterminate) && colour === 'blue'}
			class:bg-cyan-500={(checked || indeterminate) && colour === 'cyan'}
			class:bg-emerald-500={(checked || indeterminate) && colour === 'emerald'}
			class:bg-fuchsia-500={(checked || indeterminate) && colour === 'fuchsia'}
			class:bg-green-500={(checked || indeterminate) && colour === 'green'}
			class:bg-indigo-500={(checked || indeterminate) && colour === 'indigo'}
			class:bg-lime-500={(checked || indeterminate) && colour === 'lime'}
			class:bg-orange-500={(checked || indeterminate) && colour === 'orange'}
			class:bg-pink-500={(checked || indeterminate) && colour === 'pink'}
			class:bg-purple-500={(checked || indeterminate) && colour === 'purple'}
			class:bg-red-500={(checked || indeterminate) && colour === 'red'}
			class:bg-rose-500={(checked || indeterminate) && colour === 'rose'}
			class:bg-sky-500={(checked || indeterminate) && colour === 'sky'}
			class:bg-teal-500={(checked || indeterminate) && colour === 'teal'}
			class:bg-violet-500={(checked || indeterminate) && colour === 'violet'}
			class:bg-yellow-500={(checked || indeterminate) && colour === 'yellow'}
			class:border-amber-500={colour === 'amber'}
			class:border-blue-500={colour === 'blue'}
			class:border-cyan-500={colour === 'cyan'}
			class:border-emerald-500={colour === 'emerald'}
			class:border-fuchsia-500={colour === 'fuchsia'}
			class:border-green-500={colour === 'green'}
			class:border-indigo-500={colour === 'indigo'}
			class:border-lime-500={colour === 'lime'}
			class:border-orange-500={colour === 'orange'}
			class:border-pink-500={colour === 'pink'}
			class:border-purple-500={colour === 'purple'}
			class:border-red-500={colour === 'red'}
			class:border-rose-500={colour === 'rose'}
			class:border-sky-500={colour === 'sky'}
			class:border-teal-500={colour === 'teal'}
			class:border-violet-500={colour === 'violet'}
			class:border-yellow-500={colour === 'yellow'}
			class:hover:border-amber-400={!(checked || indeterminate) && colour === 'amber'}
			class:hover:border-blue-400={!(checked || indeterminate) && colour === 'blue'}
			class:hover:border-cyan-400={!(checked || indeterminate) && colour === 'cyan'}
			class:hover:border-emerald-400={!(checked || indeterminate) && colour === 'emerald'}
			class:hover:border-fuchsia-400={!(checked || indeterminate) && colour === 'fuchsia'}
			class:hover:border-green-400={!(checked || indeterminate) && colour === 'green'}
			class:hover:border-indigo-400={!(checked || indeterminate) && colour === 'indigo'}
			class:hover:border-lime-400={!(checked || indeterminate) && colour === 'lime'}
			class:hover:border-orange-400={!(checked || indeterminate) && colour === 'orange'}
			class:hover:border-pink-400={!(checked || indeterminate) && colour === 'pink'}
			class:hover:border-purple-400={!(checked || indeterminate) && colour === 'purple'}
			class:hover:border-red-400={!(checked || indeterminate) && colour === 'red'}
			class:hover:border-rose-400={!(checked || indeterminate) && colour === 'rose'}
			class:hover:border-sky-400={!(checked || indeterminate) && colour === 'sky'}
			class:hover:border-teal-400={!(checked || indeterminate) && colour === 'teal'}
			class:hover:border-violet-400={!(checked || indeterminate) && colour === 'violet'}
			class:hover:border-yellow-400={!(checked || indeterminate) && colour === 'yellow'}
			bind:checked
			{indeterminate}
		/>
		{#if checked || indeterminate}
			<div transition:scale={{ duration: 100 }} class="absolute inset-0 grid place-items-center">
				<Icon icon={indeterminate ? 'Minus' : 'Check'} {size} />
			</div>
		{/if}
	</span>
	<Text element="span" size={textSize[size ?? 'md']}>{label}</Text>
</label>
