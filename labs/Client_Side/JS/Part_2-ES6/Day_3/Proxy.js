const PERSON_VALIDATOR = {
    get(target, key) {
        if (key in target) {
            return target[key];
        } else {
            throw new Error(`Invalid property: ${key}`);
        }
    },

    set(obj, prop, value) {
        switch (prop) {
            case 'name':
                this.validateName(value);
                break;

            case 'address':
                this.validateAddress(value);
                break;

            case 'age':
                this.validateAge(value);
                break;

            default:
                throw new Error(`Invalid property: ${prop}`);
        }

        obj[prop] = value;

        return true;
    },


    validateName(value){
        if (typeof value !== 'string') {
            throw new Error('Name must be a string');
        }

        if (value.length != 7) {
            throw new Error('Name must be 7 characters');
        }
    },

    validateAddress(value) {
        if (typeof value !== 'string') {
            throw new Error('Address must be a string');
        }
    },

    validateAge(value) {
        if (typeof value !== 'number') {
            throw new Error('Age must be a number');
        }

        if (value < 25 || value > 60) {
            throw new Error('Age must be between 25 and 60');
        }
    }
}


export default PERSON_VALIDATOR;