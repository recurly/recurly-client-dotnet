namespace Recurly
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Checks if the <paramref name="source"/> <see cref="Account.AccountState"/> contains the flag for the <paramref name="target"/> <see cref="Account.AccountState"/>.
        /// </summary>
        /// <param name="source">The <see cref="Account.AccountState"/> to question for the given <paramref name="target"/> flag.</param>
        /// <param name="target">The <see cref="Account.AccountState"/> flag to question for.</param>
        /// <returns>true if the <paramref name="source"/> flags contain the <paramref name="target"/> flags, false otherwise.</returns>
        public static bool Is(this Account.AccountState source, Account.AccountState target)
        {
            return (source & target) == target;
        }

        /// <summary>
        /// Removes the <paramref name="target"/> <see cref="Account.AccountState"/> flag from the <paramref name="source"/> <see cref="Account.AccountState"/> (if it exists).
        /// </summary>
        /// <param name="source">The <see cref="Account.AccountState"/> to remove the <paramref name="target"/> from.</param>
        /// <param name="target">The <see cref="Account.AccountState"/> flag to attempt to remove from <paramref name="source"/>.</param>
        /// <returns><paramref name="source"/> with <paramref name="target"/> removed if <paramref name="target"/> was present, merely <paramref name="source"/> otherwise.</returns>
        public static Account.AccountState Remove(this Account.AccountState source, Account.AccountState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        /// <summary>
        /// Adds the <paramref name="target"/> <see cref="Account.AccountState"/> to the given <paramref name="source"/> <see cref="Account.AccountState"/>.
        /// </summary>
        /// <param name="source">The <see cref="Account.AccountState"/> flags to be added to.</param>
        /// <param name="target">The <see cref="Account.AccountState"/> flags to add to <paramref name="source"/>.</param>
        /// <returns>The result of the bitwise OR of the two <see cref="Account.AccountState"/> flags.</returns>
        public static Account.AccountState Add(this Account.AccountState source, Account.AccountState target)
        {
            return source | target;
        }

        /// <summary>
        /// Checks if the <paramref name="source"/> <see cref="Subscription.SubscriptionState"/> contains the flag for the <paramref name="target"/> <see cref="Subscription.SubscriptionState"/>.
        /// </summary>
        /// <param name="source">The <see cref="Subscription.SubscriptionState"/> to question for the given <paramref name="target"/> flag.</param>
        /// <param name="target">The <see cref="Subscription.SubscriptionState"/> flag to question for.</param>
        /// <returns>true if the <paramref name="source"/> flags contain the <paramref name="target"/> flags, false otherwise.</returns>
        public static bool Is(this Subscription.SubscriptionState source, Subscription.SubscriptionState target)
        {
            return (source & target) == target;
        }

        /// <summary>
        /// Removes the <paramref name="target"/> <see cref="Subscription.SubscriptionState"/> flag from the <paramref name="source"/> <see cref="Subscription.SubscriptionState"/> (if it exists).
        /// </summary>
        /// <param name="source">The <see cref="Subscription.SubscriptionState"/> to remove the <paramref name="target"/> from.</param>
        /// <param name="target">The <see cref="Subscription.SubscriptionState"/> flag to attempt to remove from <paramref name="source"/>.</param>
        /// <returns><paramref name="source"/> with <paramref name="target"/> removed if <paramref name="target"/> was present, merely <paramref name="source"/> otherwise.</returns>
        public static Subscription.SubscriptionState Remove(this Subscription.SubscriptionState source, Subscription.SubscriptionState target)
        {
            return source.Is(target) ? source ^ target : source;
        }

        /// <summary>
        /// Adds the <paramref name="target"/> <see cref="Subscription.SubscriptionState"/> to the given <paramref name="source"/> <see cref="Subscription.SubscriptionState"/>.
        /// </summary>
        /// <param name="source">The <see cref="Subscription.SubscriptionState"/> flags to be added to.</param>
        /// <param name="target">The <see cref="Subscription.SubscriptionState"/> flags to add to <paramref name="source"/>.</param>
        /// <returns>The result of the bitwise OR of the two <see cref="Subscription.SubscriptionState"/> flags.</returns>
        public static Subscription.SubscriptionState Add(this Subscription.SubscriptionState source, Subscription.SubscriptionState target)
        {
            return source | target;
        }
    }
}