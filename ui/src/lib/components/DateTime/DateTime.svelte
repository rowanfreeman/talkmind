<script lang="ts">
	import Dayjs from '$lib/components/Dayjs';

	interface $$Props {
		format?: 'LT' | 'LTS' | 'L' | 'LL' | 'LLL' | 'LLLL' | 'l' | 'll' | 'lll' | 'llll';
		value?: Date;
	}

	export let format: $$Props['format'] = 'LLLL',
		value: $$Props['value'] = undefined;

	$: formatted = value && Dayjs(value).format(format);
</script>

{#if value}
	<time datetime={formatted}>
		{formatted}
	</time>
{/if}
