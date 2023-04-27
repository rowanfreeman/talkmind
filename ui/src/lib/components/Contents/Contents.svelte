<script lang="ts">
	interface $$Props {
		class?: string;
	}

	let className: $$Props['class'] = '';

	export { className as class };
</script>

<div class="contents {className}">
	<slot />
</div>
