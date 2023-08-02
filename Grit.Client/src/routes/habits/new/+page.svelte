<script lang="ts">
	import { enhance } from '$app/forms';
    import { Textarea, Label, Input, Button, Toast } from 'flowbite-svelte';

    let newName = '';
    let newDescription = '';
    let success = false
    export let form;

    // recomputing if the value of form changes
    // setting success to true
    $: {
        if (form && form.success) {
            success = true;
            setTimeout(() => {
                success = false;
            }, 3000);
        }
    }
</script>

{#if success}
    <Toast color="green">
        Habit Created successfully.
    </Toast>
{/if}

<div class="min-h-screen flex items-center justify-center bg-gray-50 ">
    <div class="rounded overflow-hidden w-2/3 p-8 m-8">
        <form method="post" use:enhance class="bg-white shadow-md rounded mx-2 py-2 px-2 my-4">
            {#if success}
                <Toast color="green">
                    Habit Created successfully.
                </Toast>
            {/if}
            <div class="flex items-center justify-center my-4 px-2 py-2">
                <h1 class="text-lg text-bold"><p class="text-orange-600">New Habit</p></h1>
            </div>
            <div class="py-2 my-2 mx-2 px-1">
                <Label for="name" defaultClass="text-bold">Name</Label>
            </div>
            <div class="py-2 my-2 mx-2 px-1">
                <Input bind:value={newName} type="text" name="name" placeholder="Enter Name here" required  />
            </div>
            <div class="py-2 my-2 mx-2 px-1">
                <Label for="description" defaultClass="text-bold">Description</Label>
            </div>
            <div class="py-2 my-2 mx-2 px-1">
                <Textarea bind:value={newDescription} name="description" placeholder="Enter description" rows="4" />
            </div>
            <div class="flex items-center justify-center py-2 my-2 mx-2 px-1">
                <Button disabled={!newName} type="submit" color="green">Create</Button>
            </div>
        </form>
    </div>
</div>