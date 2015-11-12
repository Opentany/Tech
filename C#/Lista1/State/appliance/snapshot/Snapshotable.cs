namespace State.appliance.snapshot
{
    public interface Snapshotable
    {

        /**
         * Create a new {@link Snapshot} with internal state
         * 
         * @return an {@link Snapshot}
         */
        Snapshot takeSnapshot();

        /**
         * Restore intenal state of {@link Snapshotable} with an instance of
         * {@link Snapshot}
         * 
         * @param snapshot
         *            The snapshot from internal state will be read
         */
        void restoreFromSnapshot(Snapshot snapshot);

    }
}