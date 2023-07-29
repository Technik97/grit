<script lang="ts">
    import { Navbar, NavBrand, NavLi, NavUl } from 'flowbite-svelte'

    let divClass = 'w-full ml-auto lg:block lg:w-auto order-1 lg:order-none';
	let ulClass =
		'flex flex-col py-3 my-4 lg:flex-row lg:my-0 text-sm font-medium gap-4 dark:lg:bg-transparent lg:bg-white lg:border-0';
  </script>
  
  <Navbar let:hidden let:toggle>
    <NavBrand href="/" class="lg:ml-64">
        <span class="self-center whitespace-nowrap text-xl font-semibold dark:text-white pl-4">
            GRIT
        </span>
    </NavBrand>
    <NavUl
        {hidden}
        {divClass}
        {ulClass}
        nonActiveClass="md:!pl-3 md:!py-2 lg:!pl-0 text-gray-700 hover:bg-gray-100 lg:hover:bg-transparent lg:border-0 lg:hover:text-primary-700 dark:text-white lg:dark:hover:text-primary-700 dark:hover:bg-gray-700 dark:hover:text-white lg:dark:hover:bg-transparent"
        activeClass="md:!pl-3 md:!py-2 lg:!pl-0 lg:text-primary-700 text-white dark:text-white dark:lg:text-primary-500 bg-primary-700 lg:bg-transparent dark:bg-primary-600 lg:dark:bg-transparent cursor-default"
    >
        <NavLi
            class="lg:px-2 lg:mb-0"
            href="https://github.com/shinokada/flowbite-sveltekit-responsive-sidebar-layout"
            >GitHub</NavLi
        >
    </NavUl>
</Navbar>