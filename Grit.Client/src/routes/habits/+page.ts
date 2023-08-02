import type { Habit } from '../../data/IHabits';

export async function load({fetch}) {
    const response = await fetch('http://localhost:5100/api/habits')

    const habits: Habit[] = await response.json();

    return { habits }
}