export const actions = {
    default: async ( event ) => {
        const formData = await event.request.formData();
        const name = formData.get('name');
        const description = formData.get('description');

        const data = {
            name: name,
            description: description
        }

        await fetch('http://localhost:5100/api/habits/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
                },
            body: JSON.stringify(data)
        })

        return { success: true }
    }
}