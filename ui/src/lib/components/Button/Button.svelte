<script lang="ts">
	import type { CommonSize } from '$lib/types/size';
	import type { Colour } from '$lib/types/colour';
	import type { ButtonVariant } from '.';

	interface $$Props {
		colour?: Colour;
		disabled?: boolean;
		round?: boolean;
		size?: CommonSize;
		variant?: ButtonVariant;
	}

	export let colour: $$Props['colour'] = undefined,
		disabled: $$Props['disabled'] = false,
		round: $$Props['round'] = false,
		size: $$Props['size'] = 'md',
		variant: $$Props['variant'] = 'filled';
</script>

<button
	class:min-w-2={size === 'xs'}
	class:min-w-4={size === 'sm'}
	class:min-w-8={size === 'md'}
	class:min-w-16={size === 'lg'}
	class:min-w-32={size === 'xl'}
	class:text-xs={size === 'xs'}
	class:text-sm={size === 'sm'}
	class:text-md={size === 'md'}
	class:text-lg={size === 'lg'}
	class:text-xl={size === 'xl'}
	class:p-[1px]={size === 'xs'}
	class:p-[2px]={size === 'sm'}
	class:p-2={size === 'md'}
	class:p-3={size === 'lg'}
	class:p-4={size === 'xl'}
	class:gap-1={size === 'xs' || size === 'sm'}
	class:gap-2={size === 'md' || size === 'lg'}
	class:gap-3={size === 'xl'}
	class:rounded-full={round}
	class:rounded={!round}
	class:cursor-not-allowed={disabled}
	class:outline-offset-1={size === 'xs' || size === 'sm'}
	class:outline-1={size === 'xs' || size === 'sm'}
	class:outline-offset-2={size === 'md' || size === 'lg'}
	class:outline-2={size === 'md' || size === 'lg'}
	class:outline-offset-4={size === 'xl'}
	class:outline-4={size === 'xl'}
	class:red={colour === 'red'}
	class:orange={colour === 'orange'}
	class:amber={colour === 'amber'}
	class:yellow={colour === 'yellow'}
	class:lime={colour === 'lime'}
	class:green={colour === 'green'}
	class:emerald={colour === 'emerald'}
	class:teal={colour === 'teal'}
	class:cyan={colour === 'cyan'}
	class:sky={colour === 'sky'}
	class:blue={colour === 'blue'}
	class:indigo={colour === 'indigo'}
	class:violet={colour === 'violet'}
	class:purple={colour === 'purple'}
	class:fuchsia={colour === 'fuchsia'}
	class:pink={colour === 'pink'}
	class:rose={colour === 'rose'}
	class:neutral={colour === undefined}
	class="flex items-center focus-visible:outline"
	{disabled}
	on:mousedown
	on:mouseup
	on:click
>
	<slot />
</button>
