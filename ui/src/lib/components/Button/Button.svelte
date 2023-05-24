<script lang="ts">
	import { blur } from 'svelte/transition';

	import Tooltip from '$lib/components/Tooltip';
	import type { ButtonProps } from '.';
	import Icon from '$lib/components/Icon';
	import Loader from '$lib/components/Loader';

	interface $$Props extends ButtonProps {}

	export let colour: $$Props['colour'] = undefined,
		disabled: $$Props['disabled'] = false,
		iconLeft: $$Props['iconLeft'] = undefined,
		iconRight: $$Props['iconRight'] = undefined,
		loading: $$Props['loading'] = false,
		round: $$Props['round'] = false,
		size: $$Props['size'] = 'md',
		tooltip: $$Props['tooltip'] = { content: '' },
		variant: $$Props['variant'] = 'filled';

	let ref: HTMLElement | undefined = undefined;
</script>

<Tooltip content={tooltip?.content} placement={tooltip?.placement} {ref}>
	<div class="sticky inline-flex pointer-events-none">
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
			class:outline-offset-1={size === 'xs' || size === 'sm'}
			class:outline-1={size === 'xs' || size === 'sm'}
			class:outline-offset-2={size === 'md' || size === 'lg'}
			class:outline-2={size === 'md' || size === 'lg'}
			class:outline-offset-4={size === 'xl'}
			class:outline-4={size === 'xl'}
			class:neutral={colour === undefined}
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
			class:button-filled={variant === 'filled'}
			class:button-ghost={variant === 'ghost'}
			class:button-outline={variant === 'outline'}
			class:button-text={variant === 'text'}
			class:size-xs={size === 'xs'}
			class:size-sm={size === 'sm'}
			class:size-md={size === 'md'}
			class:size-lg={size === 'lg'}
			class:size-xl={size === 'xl'}
			class="flex items-center focus-visible:outline disabled:cursor-not-allowed pointer-events-auto"
			disabled={disabled || loading}
			on:mousedown
			on:mouseup
			on:click
			bind:this={ref}
		>
			{#if iconLeft}
				<div class:invisible={loading}>
					<Icon icon={iconLeft} {size} />
				</div>
			{/if}
			<div class:invisible={loading}>
				<slot />
			</div>
			{#if iconRight}
				<div class:invisible={loading}>
					<Icon icon={iconRight} {size} />
				</div>
			{/if}
		</button>
		{#if loading}
			<div in:blur={{ duration: 150 }} class="absolute inset-0 grid place-items-center">
				<Loader variant="spin" {size} />
			</div>
		{/if}
	</div>
</Tooltip>

<style lang="postcss">
	@import './variants/index.pcss';
</style>
