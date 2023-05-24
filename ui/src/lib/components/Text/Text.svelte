<script lang="ts">
	import { Em, Strikethrough, Strong, type TextSize } from '.';
	import type { Colour } from '$lib/types/colour';

	interface $$Props {
		class?: string;
		colour?: Colour;
		element?: 'p' | 'div' | 'span' | 'h1' | 'h2' | 'h3' | 'h4';
		emphasis?: boolean;
		size?: TextSize;
		strikethrough?: boolean;
		strong?: boolean;
	}

	export let colour: $$Props['colour'] = undefined,
		element: $$Props['element'] = 'p',
		emphasis: $$Props['emphasis'] = false,
		strikethrough: $$Props['strikethrough'] = false,
		size: $$Props['size'] = 'base',
		strong: $$Props['strong'] = false;

	$: isHeading = ['h1', 'h2', 'h3', 'h4'].includes(element ?? 'p');

	let className = '';

	export { className as class };
</script>

<svelte:element
	this={element}
	class:text-xs={size === 'xs'}
	class:text-sm={size === 'sm'}
	class:text-base={size === 'base' && !isHeading}
	class:text-lg={size === 'lg' || element === 'h4'}
	class:text-xl={size === 'xl' || element === 'h3'}
	class:text-2xl={size === '2xl' || element === 'h2'}
	class:text-3xl={size === '3xl' || element === 'h1'}
	class:text-4xl={size === '4xl'}
	class:text-5xl={size === '5xl'}
	class:text-6xl={size === '6xl'}
	class:text-7xl={size === '7xl'}
	class:text-8xl={size === '8xl'}
	class:text-9xl={size === '9xl'}
	class:text-red-500={colour === 'red'}
	class:text-orange-500={colour === 'orange'}
	class:text-amber-500={colour === 'amber'}
	class:text-yellow-500={colour === 'yellow'}
	class:text-lime-500={colour === 'lime'}
	class:text-green-500={colour === 'green'}
	class:text-emerald-500={colour === 'emerald'}
	class:text-teal-500={colour === 'teal'}
	class:text-cyan-500={colour === 'cyan'}
	class:text-sky-500={colour === 'sky'}
	class:text-blue-500={colour === 'blue'}
	class:text-indigo-500={colour === 'indigo'}
	class:text-violet-500={colour === 'violet'}
	class:text-purple-500={colour === 'purple'}
	class:text-fuchsia-500={colour === 'fuchsia'}
	class:text-pink-500={colour === 'pink'}
	class:text-rose-500={colour === 'rose'}
	class={className}
>
	<Em {emphasis}>
		<Strikethrough {strikethrough}>
			<Strong {strong}>
				<slot />
			</Strong>
		</Strikethrough>
	</Em>
</svelte:element>
