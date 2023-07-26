<script lang="ts">
	import type { CommonSize } from '$lib/types/size';
	import type { Colour } from '$lib/types/colour';
	import Text, { type TextSize } from '$lib/components/Text';

	interface $$Props {
		checked?: boolean;
		colour?: Colour;
		label?: string;
		size?: CommonSize;
	}

	export let checked: $$Props['checked'] = false,
		colour: $$Props['colour'] = 'sky',
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
	<input type="checkbox" on:change class="sr-only peer" bind:checked />
	<div
		class={`aspect-video rounded-full cursor-pointer transition-colors duration-150 relative ${
			!checked ? 'bg-neutral-400' : ''
		}`}
		class:w-4={size === 'xs'}
		class:w-6={size === 'sm'}
		class:w-8={size === 'md'}
		class:w-12={size === 'lg'}
		class:w-16={size === 'xl'}
		class:peer-checked:bg-amber-500={colour === 'amber'}
		class:peer-checked:bg-blue-500={colour === 'blue'}
		class:peer-checked:bg-cyan-500={colour === 'cyan'}
		class:peer-checked:bg-emerald-500={colour === 'emerald'}
		class:peer-checked:bg-fuchsia-500={colour === 'fuchsia'}
		class:peer-checked:bg-green-500={colour === 'green'}
		class:peer-checked:bg-indigo-500={colour === 'indigo'}
		class:peer-checked:bg-lime-500={colour === 'lime'}
		class:peer-checked:bg-orange-500={colour === 'orange'}
		class:peer-checked:bg-pink-500={colour === 'pink'}
		class:peer-checked:bg-purple-500={colour === 'purple'}
		class:peer-checked:bg-red-500={colour === 'red'}
		class:peer-checked:bg-rose-500={colour === 'rose'}
		class:peer-checked:bg-sky-500={colour === 'sky'}
		class:peer-checked:bg-teal-500={colour === 'teal'}
		class:peer-checked:bg-violet-500={colour === 'violet'}
		class:peer-checked:bg-yellow-500={colour === 'yellow'}
	>
		<div class="absolute inset-0 flex items-center">
			<div
				class="absolute h-[80%] left-[5%] aspect-square rounded-full bg-neutral-100 transition-transform duration-150"
				class:translate-x-full={checked}
			/>
		</div>
	</div>
	<Text element="span" size={textSize[size ?? 'md']}>{label}</Text>
</label>
