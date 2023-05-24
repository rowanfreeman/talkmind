<script lang="ts">
	import type { CommonSize } from 'lib/types/size';

	type LoaderVariant = 'bloom' | 'spin';

	interface $$Props {
		size?: CommonSize;
		variant?: LoaderVariant;
	}

	export let size: $$Props['size'] = 'md',
		variant: $$Props['variant'] = 'bloom';

	const sizeMap: Record<CommonSize, number> = {
		xs: 8,
		sm: 16,
		md: 24,
		lg: 32,
		xl: 40,
	};

	$: resolvedSize = sizeMap[size ?? 'md'];
</script>

{#if variant === 'bloom'}
	<svg
		viewBox="0 0 40 40"
		xmlns="http://www.w3.org/2000/svg"
		stroke="currentColor"
		width={resolvedSize}
		height={resolvedSize}
	>
		<g fill="none" fill-rule="evenodd" stroke-width="2">
			<circle cx="20" cy="20" r="18">
				<animate
					attributeName="r"
					begin="0s"
					dur="1.8s"
					values="18; 10; 18"
					calcMode="linear"
					repeatCount="indefinite"
				/>
				<animate
					attributeName="stroke-opacity"
					begin="0s"
					dur="1.8s"
					values="1; 0; 1"
					calcMode="linear"
					repeatCount="indefinite"
				/>
				<animate
					attributeName="stroke-width"
					begin="0s"
					dur="1.8s"
					values="2; 4; 2"
					calcMode="linear"
					repeatCount="indefinite"
				/>
			</circle>
			<circle cx="20" cy="20" r="10">
				<animate
					attributeName="r"
					begin="0s"
					dur="1.8s"
					values="10; 18; 10"
					calcMode="linear"
					repeatCount="indefinite"
				/>
				<animate
					attributeName="stroke-opacity"
					begin="0s"
					dur="1.8s"
					values="0; 1; 0"
					calcMode="linear"
					repeatCount="indefinite"
				/>
				<animate
					attributeName="stroke-width"
					begin="0s"
					dur="1.8s"
					values="4; 2; 4"
					calcMode="linear"
					repeatCount="indefinite"
				/>
			</circle>
		</g>
	</svg>
{/if}

{#if variant === 'spin'}
	<svg
		height={resolvedSize}
		width={resolvedSize}
		xmlns="http://www.w3.org/2000/svg"
		fill="none"
		viewBox="0 0 24 24"
		class="animate-spin"
	>
		<circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4" />
		<path
			class="opacity-75"
			fill="currentColor"
			d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
		/>
	</svg>
{/if}
