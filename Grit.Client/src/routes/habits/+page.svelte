<script lang="ts">
    export let data;
</script>

<h1>Habits</h1>

<p>Showing {data.habits.length} habits.</p>

<ul>
    {#each data.habits as habit}
        <li><p>{habit.name}</p></li>
    {/each}
</ul>