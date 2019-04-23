<template>
    <div class="label">
        <div class="label__content">{{ value }}</div>
    </div>
</template>
<script>
    export default {
        name: "App",
        data() {
            return {
                value: 25,
            };
        },
    };
</script>
<style lang="scss">
.label {
    &__content {
        color: blue;
        font-size: 20px;
        font-weight: bold;
        text-decoration: overline dotted;
    }
}
</style>
