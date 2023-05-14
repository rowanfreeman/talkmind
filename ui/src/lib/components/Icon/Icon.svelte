<script lang="ts">
	import type { ComponentProps } from 'svelte';
	import { Icon } from '@steeze-ui/svelte-icon';
	import * as heroicons from '@steeze-ui/heroicons';

	import type { CommonSize } from '$lib/types/size';
	import type { IconType } from '.';

	interface $$Props {
		icon?: IconType;
		size?: CommonSize;
		src?: ComponentProps<Icon>['src'];
		theme?: ComponentProps<Icon>['theme'];
	}

	export let icon: $$Props['icon'] = undefined,
		size: $$Props['size'] = 'md',
		src: $$Props['src'] = undefined,
		theme: $$Props['theme'] = 'solid';

	const sizeMap: Record<CommonSize, number> = {
		xs: 0.6,
		sm: 0.8,
		md: 1,
		lg: 2,
		xl: 3,
	};

	$: derivedIcon = src ?? (icon ? heroicons[icon!] : undefined);
</script>

{#if derivedIcon}
	<Icon class="text-sm" src={derivedIcon} {theme} size={`${sizeMap[size ?? 'md']}rem`} />
{/if}
