<script>
    import "../app.css"
	import Navbar from "../components/common/Navbar.svelte";


	let divClass = 'w-full ml-auto lg:block lg:w-auto order-1 lg:order-none';
	let ulClass =
		'flex flex-col py-3 my-4 lg:flex-row lg:my-0 text-sm font-medium gap-4 dark:lg:bg-transparent lg:bg-white lg:border-0';
	let navDivClass =
		'bg-white dark:bg-gray-800 text-gray-500 dark:text-gray-400 border-gray-200 dark:border-gray-700 divide-gray-200 dark:divide-gray-700 flex items-center justify-between w-full mx-auto py-1.5 px-4';
</script>


<header class="flex-none w-full mx-auto bg-white dark:bg-slate-950">
    <Navbar />
</header>
<main class="w-full mx-auto">
    <slot />
</main>