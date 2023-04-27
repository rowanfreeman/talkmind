<script lang="ts">
	import type { CommonSize } from '$lib/types/size';
	import type { AvatarVariant } from '.';
	import type Colour from '$lib/types/colour';

	interface $$Props {
		colour?: Colour;
		size?: CommonSize;
		variant?: AvatarVariant;
	}

	export let colour: $$Props['colour'] = undefined,
		size: $$Props['size'] = 'md',
		variant: $$Props['variant'] = 'round';
</script>

<div
	class="flex justify-center items-center aspect-square select-none overflow-hidden bg-gradient-to-br from-black/50 to-black/50"
	class:h-4={size === 'xs'}
	class:h-8={size === 'sm'}
	class:h-12={size === 'md'}
	class:h-18={size === 'lg'}
	class:h-24={size === 'xl'}
	class:text-xs={size === 'xs'}
	class:text-sm={size === 'sm'}
	class:text-md={size === 'md'}
	class:text-lg={size === 'lg'}
	class:text-xl={size === 'xl'}
	class:rounded-full={variant === 'round'}
	class:rounded={variant === 'rounded'}
	class:from-red-400={colour === 'red'}
	class:to-red-600={colour === 'red'}
	class:from-orange-400={colour === 'orange'}
	class:to-orange-600={colour === 'orange'}
	class:from-amber-400={colour === 'amber'}
	class:to-amber-600={colour === 'amber'}
	class:from-yellow-400={colour === 'yellow'}
	class:to-yellow-600={colour === 'yellow'}
	class:from-lime-400={colour === 'lime'}
	class:to-lime-600={colour === 'lime'}
	class:from-green-400={colour === 'green'}
	class:to-green-600={colour === 'green'}
	class:from-emerald-400={colour === 'emerald'}
	class:to-emerald-600={colour === 'emerald'}
	class:from-teal-400={colour === 'teal'}
	class:to-teal-600={colour === 'teal'}
	class:from-cyan-400={colour === 'cyan'}
	class:to-cyan-600={colour === 'cyan'}
	class:from-sky-400={colour === 'sky'}
	class:to-sky-600={colour === 'sky'}
	class:from-blue-400={colour === 'blue'}
	class:to-blue-600={colour === 'blue'}
	class:from-indigo-400={colour === 'indigo'}
	class:to-indigo-600={colour === 'indigo'}
	class:from-violet-400={colour === 'violet'}
	class:to-violet-600={colour === 'violet'}
	class:from-purple-400={colour === 'purple'}
	class:to-purple-600={colour === 'purple'}
	class:from-fuchsia-400={colour === 'fuchsia'}
	class:to-fuchsia-600={colour === 'fuchsia'}
	class:from-pink-400={colour === 'pink'}
	class:to-pink-600={colour === 'pink'}
	class:from-rose-400={colour === 'rose'}
	class:to-rose-600={colour === 'rose'}
>
	<span class="drop-shadow"><slot /></span>
</div>
